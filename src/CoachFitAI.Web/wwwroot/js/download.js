function downloadFileFromBase64(filename, base64) {
  // Try Blob approach for large files: convert base64 to binary and create object URL
  try {
    const binary = atob(base64);
    const len = binary.length;
    const bytes = new Uint8Array(len);
    for (let i = 0; i < len; i++) bytes[i] = binary.charCodeAt(i);
    const blob = new Blob([bytes], { type: 'application/pdf' });
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = filename;
    document.body.appendChild(link);
    link.click();
    link.remove();
    URL.revokeObjectURL(url);
  } catch {
    // Fallback to data URI for small files / older browsers
    const link = document.createElement('a');
    link.href = 'data:application/pdf;base64,' + base64;
    link.download = filename;
    document.body.appendChild(link);
    link.click();
    link.remove();
  }
}
window.downloadFileFromBase64 = downloadFileFromBase64;